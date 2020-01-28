using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoversInfrastructure.Views
{
    public interface IView
    {
        string Process(string input);
    }
}
