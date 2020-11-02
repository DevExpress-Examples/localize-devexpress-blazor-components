﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Services {
    public class SupportedCultures {
        public static CultureInfo[] Cultures { get; } = new CultureInfo[] {
            new CultureInfo("de-DE"),
            new CultureInfo("en-US"),
            new CultureInfo("ru-RU"),
            new CultureInfo("it-IT"),
        };
    }
}
