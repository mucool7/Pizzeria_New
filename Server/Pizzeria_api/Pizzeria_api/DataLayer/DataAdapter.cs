using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Pizzeria_api.DataLayer
{
    public class DataAdapter
    {
        private const string DataRootPath = "../DataFiles/";



        public T GetData<T>(string path)
        {

            try { 

                string data = GetDataString(DataRootPath+path);
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new FileNotFoundException("File Not found", ex);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("File Not found",ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void WriteData(string path,object data)
        {
            try
            {

                string obj = JsonConvert.SerializeObject(data);
                WriteDataString(path,obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private string GetDataString(string path)
        {
                string Data;

                Data = File.ReadAllText(DataRootPath+path);

                return Data;

        }


        private void WriteDataString(string path,string data)
        {
            var lastSlash = path.LastIndexOf("/");

            string directory = path.Substring(0, lastSlash);
          //  string fileName = path.Substring(lastSlash + 1, path.Length-1);
            
            if (!Directory.Exists(DataRootPath + directory))
            {
                Directory.CreateDirectory(DataRootPath+ directory);
            }
                File.WriteAllText(DataRootPath+path, data );

        }
    }
}
