// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

namespace WeeC
{
    internal class TranslationUnit
    {
    }

    internal abstract class CType { }

    internal abstract class Declaration
    {
    }

    internal class ParameterDeclaration : Declaration
    {
        public CType Type { get; set; }
        public string Name { get; set; }
    }

    internal class FunctionDeclaration : Declaration
    {
        public CType ReturnType { get; set; }
        public ParameterDeclaration[] Parameters { get; set; }
        public CompoundStatement Body { get; set; }
    }

    internal abstract class Statement
    {
    }

    internal class CompoundStatement : Statement
    {
    }

    internal abstract class Expression
    {
    }
}
