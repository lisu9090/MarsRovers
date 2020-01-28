using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoversInfrastructure.Views
{
    interface IView
    {
        string Process(string input);
    }
}
