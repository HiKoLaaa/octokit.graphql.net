﻿using System;
using System.Text;
using LinqToGraphQL.Generation.Models;
using LinqToGraphQL.Generation.Utilities;
using LinqToGraphQL.Introspection;

namespace LinqToGraphQL.Generation
{
    internal static class InterfaceGenerator
    {
        public static string Generate(TypeModel type, string rootNamespace)
        {
            var className = "I" + TypeUtilities.PascalCase(type.Name);

            return $@"using System.Linq;
using System.Linq.Expressions;
using LinqToGraphQL;
using LinqToGraphQL.Builders;

namespace {rootNamespace}
{{
    {GenerateDocComments(type)}public interface {className}
    {{{GenerateFields(type)}
    }}
}}";
        }

        private static string GenerateFields(TypeModel type)
        {
            var builder = new StringBuilder();

            if (type.Fields?.Count > 0)
            {
                var first = true;

                builder.AppendLine();

                foreach (var field in type.Fields)
                {
                    if (!first)
                    {
                        builder.AppendLine();
                        builder.AppendLine();
                    }

                    builder.Append(GenerateField(field));

                    first = false;
                }
            }

            return builder.ToString();
        }

        private static string GenerateField(FieldModel field)
        {
            var method = field.Args?.Count > 0;
            var result = GenerateDocComments(field);
            var reduced = TypeUtilities.ReduceKind(field.Type);

            switch (reduced)
            {
                case TypeKind.Scalar:
                case TypeKind.Enum:
                    result += method ?
                        GenerateScalarMethod(field, field.Type) :
                        GenerateScalarField(field, field.Type);
                    break;
                case TypeKind.Object:
                case TypeKind.Interface:
                    result += method ?
                        GenerateObjectMethod(field, field.Type) :
                        GenerateObjectField(field, field.Type);
                    break;
                case TypeKind.NonNull:
                    result += method ?
                        GenerateObjectMethod(field, field.Type.OfType) :
                        GenerateObjectField(field, field.Type.OfType);
                    break;
                case TypeKind.List:
                    result += method ?
                        GenerateListMethod(field, field.Type.OfType) :
                        GenerateListField(field, field.Type.OfType);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        private static string GenerateDocComments(TypeModel type)
        {
            if (!string.IsNullOrWhiteSpace(type.Description))
            {
                return $@"/// <summary>
    /// {type.Description}
    /// </summary>
    ";
            }
            else
            {
                return null;
            }
        }

        private static string GenerateDocComments(FieldModel field)
        {
            if (!string.IsNullOrWhiteSpace(field.Description))
            {
                var builder = new StringBuilder($@"        /// <summary>
        /// {field.Description}
        /// </summary>
");

                if (field.Args != null)
                {
                    foreach (var arg in field.Args)
                    {
                        if (!string.IsNullOrWhiteSpace(arg.Description))
                        {
                            builder.AppendLine($"        /// <param name=\"{arg.Name}\">{arg.Description}</param>");
                        }
                    }
                }

                return builder.ToString();
            }
            else
            {
                return null;
            }
        }

        private static string GenerateScalarField(FieldModel field, TypeModel type)
        {
            var name = TypeUtilities.PascalCase(field.Name);
            return $"        {TypeUtilities.GetCSharpType(type)} {name} {{ get; }}";
        }

        private static string GenerateObjectField(FieldModel field, TypeModel type)
        {
            var name = TypeUtilities.PascalCase(field.Name);
            return $"        {type.Name} {name} {{ get; }}";
        }

        private static string GenerateScalarMethod(FieldModel field, TypeModel type)
        {
            var name = TypeUtilities.PascalCase(field.Name);
            type = TypeModel.NonNull(TypeUtilities.ReduceNonNull(type));

            string arguments;
            string parameters;
            GenerateArguments(field, out arguments, out parameters);

            return $"        IQueryable<{TypeUtilities.GetCSharpType(type)}> {name}({arguments});";
        }

        private static string GenerateObjectMethod(FieldModel field, TypeModel type)
        {
            var name = TypeUtilities.PascalCase(field.Name);

            string arguments;
            string parameters;
            GenerateArguments(field, out arguments, out parameters);

            return $"        {type.Name} {name}({arguments});";
        }

        private static string GenerateListField(FieldModel field, TypeModel type)
        {
            var name = TypeUtilities.PascalCase(field.Name);
            return $"        IQueryable<{type.Name}> {name} {{ get; }}";
        }

        private static string GenerateListMethod(FieldModel field, TypeModel type)
        {
            var name = TypeUtilities.PascalCase(field.Name);

            string arguments;
            string parameters;
            GenerateArguments(field, out arguments, out parameters);

            return $"        IQueryable<{type.Name}> {name}({arguments});";
        }

        private static void GenerateArguments(FieldModel field, out string arguments, out string parameters)
        {
            var argBuilder = new StringBuilder();
            var paramBuilder = new StringBuilder();
            var first = true;

            foreach (var arg in field.Args)
            {
                if (!first)
                {
                    argBuilder.Append(", ");
                    paramBuilder.Append(", ");
                }

                argBuilder.Append(TypeUtilities.GetCSharpType(arg.Type));
                argBuilder.Append(' ');
                argBuilder.Append(arg.Name);
                paramBuilder.Append(arg.Name);

                if (arg.DefaultValue != null)
                {
                    argBuilder.Append(" = ");
                    argBuilder.Append(TypeUtilities.GetCSharpLiteral(arg.DefaultValue, arg.Type));
                }

                first = false;
            }

            arguments = argBuilder.ToString();
            parameters = paramBuilder.ToString();
        }
    }
}
