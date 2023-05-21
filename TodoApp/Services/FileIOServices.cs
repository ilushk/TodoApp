using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TodoApp.Services
{
    class FileIOServices
    {
        private readonly string PATH;

        public FileIOServices (string path)
        {
            PATH = path;
        }

        public BindingList<TodoModel> LoadData()
        {
            var fileExist = File.Exists (PATH);
            if (fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel> ();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd ();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }

            
        }

        public void SaveData(object todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            { 
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            
            }
        
        
        }
    }
}
