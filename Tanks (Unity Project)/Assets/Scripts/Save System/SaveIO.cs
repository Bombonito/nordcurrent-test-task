using System.IO;
using Save_System.Data;
using UnityEngine;

namespace Save_System
{
    public static class SaveIO
    {
        public static readonly string DEFAULT_PATH = Application.dataPath;
        public static readonly string DEFAULT_SAVE_NAME = "tanks_demo_save.json";
        public static string SAVE_PATH => Path.Combine(DEFAULT_PATH, DEFAULT_SAVE_NAME);
        
        private static Save _dump;

        public static void Write(Save save)
        {
            var saveJson = JsonUtility.ToJson(save, true);
            File.WriteAllText(SAVE_PATH, saveJson);
        }
        
        public static Save Read()
        {
            var saveJson = File.ReadAllText(SAVE_PATH);
            return JsonUtility.FromJson<Save>(saveJson);
        }
    }
}