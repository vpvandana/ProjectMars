﻿using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProjectMars.Hooks
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {
        [BeforeScenario]
        public void BeforeScenarioWithTag() 
        {
            Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            close();
        }
    }
}
