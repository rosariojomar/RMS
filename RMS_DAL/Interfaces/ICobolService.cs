﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface ICobolService
    {

        void WriteLog(int action, string contentsValue, string path);

    }
}
