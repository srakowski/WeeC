﻿// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System.Diagnostics;
using System.Linq;

namespace WeeC
{
    public class Script
    {
        public void LoadString(string code)
        {
            var tokens = Lexer.Analyze(code).ToArray();
        }
    }
}
