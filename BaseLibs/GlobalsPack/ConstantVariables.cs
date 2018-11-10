using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.GlobalsPack
{
   public class ConstantVariables
    {
        public static string CurrentAssemblyPath = Directory.GetCurrentDirectory();
        public static string DBPath { get; set; } = Directory.GetCurrentDirectory() + "\\UniWeb\\Data\\UniWeb.db";
    }
}
