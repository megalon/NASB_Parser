using JsonDumper.Converters;
using NASB_Parser;
using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace JsonDumper
{
    internal class Program
    {
        private static JsonSerializer serialization = new JsonSerializer()
        {
            Converters =
                {
                new CheckThingConverter(),
                    new FloatSourceConverter(),
                    new JumpConverter(),
                    new ObjectSourceConverter(),
                    new StateActionConverter(),
                    new Vector3Converter(),
                    new StringEnumConverter()
                },
        };

        private static void Write(string dst, string fullPath, bool splitFileByState)
        {
            var watch = new Stopwatch();
            watch.Start();
            BulkSerializeReader ser;
            using (var fsread = File.OpenRead(fullPath))
                ser = new BulkSerializeReader(fsread);
            watch.Stop();
            Console.WriteLine($"Parsing took: {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            var data = new SerialMoveset(ser);
            watch.Stop();
            Console.WriteLine($"Creation of type structure took: {watch.Elapsed}");
            watch.Reset();
            Console.WriteLine("Json dump...");

            if (splitFileByState)
            {
                var outDir = Path.Combine(dst, Path.GetFileNameWithoutExtension(fullPath));
                if (!Directory.Exists(outDir))
                    Directory.CreateDirectory(outDir);
                foreach (IdState state in data.States)
                {
                    var outpFile = Path.Combine(outDir, state.Id) + ".json";
                    WriteSpecificFile(outpFile, state);
                }
            } else
            {
                var outpFile = Path.GetFileNameWithoutExtension(fullPath);
                outpFile = Path.Combine(dst, outpFile) + ".json";
                WriteSpecificFile(outpFile, data);
            }

            watch.Start();
            watch.Stop();
            Console.WriteLine($"Creation of JSON took: {watch.Elapsed}");
        }

        private static void WriteSpecificFile(string outpFile, object data)
        {
            if (File.Exists(outpFile))
                File.Delete(outpFile);
            using var fs = File.OpenWrite(outpFile);
            using var writer = new StreamWriter(fs);
            serialization.Serialize(writer, data);
        }

        private static void Read(string path)
        {
            var watch = new Stopwatch();
            watch.Start();
            var data = new JsonTextReader(File.OpenText(path));
            var dataToWrite = serialization.Deserialize<SerialMoveset>(data);
            watch.Stop();
            Console.WriteLine($"Deserialization took: {watch.Elapsed}");
            var outpFile = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path)) + "_2.json";
            if (File.Exists(outpFile))
                File.Delete(outpFile);
            watch.Reset();
            watch.Start();
            using var fs = File.OpenWrite(outpFile);
            using var writer = new StreamWriter(fs);
            serialization.Serialize(writer, dataToWrite);
            watch.Stop();

            Console.WriteLine($"Creation of JSON took: {watch.Elapsed}");
        }

        private static void ReadWrite(string fullPathJson, string dstFolder)
        {
            var watch = new Stopwatch();
            watch.Start();
            var data = new JsonTextReader(File.OpenText(fullPathJson));
            var dataToWrite = serialization.Deserialize<SerialMoveset>(data);
            watch.Stop();
            Console.WriteLine($"Deserialization took: {watch.Elapsed}");
            var outpFile = Path.Combine(dstFolder, Path.GetFileNameWithoutExtension(fullPathJson)) + "_new.txt";
            if (File.Exists(outpFile))
                File.Delete(outpFile);
            watch.Reset();
            var writer = new BulkSerializeWriter();
            watch.Start();
            dataToWrite.Write(writer);
            using var fs = File.OpenWrite(outpFile);
            using var dsts = new StreamWriter(fs);
            writer.Serialize(dsts);
            watch.Stop();

            Console.WriteLine($"Writeout took: {watch.Elapsed}");
        }

        // Loop through directories with split data
        private static void ReadAndJoinSplitFiles(string jsonDir, string textDir)
        {
            foreach (var dir in Directory.GetDirectories(jsonDir))
            {
                List<IdState> idStates = new List<IdState>();
                foreach (var path in Directory.EnumerateFiles(dir))
                {

                    Console.WriteLine(path);
                    var data = new JsonTextReader(File.OpenText(path));
                    var state = serialization.Deserialize<IdState>(data);
                    idStates.Add(state);
                }

                var outpFile = Path.Combine(textDir, Path.GetFileNameWithoutExtension(dir)) + "_new.txt";
                if (File.Exists(outpFile))
                    File.Delete(outpFile);
                var writer = new BulkSerializeWriter();

                SerialMoveset serialMoveset = new SerialMoveset();
                serialMoveset.SetStates(idStates);
                serialMoveset.Write(writer);
                using var fs = File.OpenWrite(outpFile);
                using var dsts = new StreamWriter(fs);
                writer.Serialize(dsts);
            }
        }

        private static void Main(string[] args)
        {
            var dst = "output";

            if (Directory.Exists(dst))
            {
                var textOut = Path.Combine(dst, "text_data");
                if (!Directory.Exists(textOut))
                    Directory.CreateDirectory(textOut);

                var jsonOut = Path.Combine(dst, "json");
                if (!Directory.Exists(jsonOut))
                    Directory.CreateDirectory(jsonOut);

                ReadAndJoinSplitFiles(jsonOut, textOut);

                Console.WriteLine("Success Reading/Writing!");
            }
            else
            {
                Console.WriteLine("Enter path to exported TextAsset data...");
                var p = @"D:\NASB_Managed\TextAsset";
                while (!File.Exists(p) && !Directory.Exists(p))
                {
                    Console.WriteLine("Enter a valid path!");
                    p = Console.ReadLine();
                }

                var jsonOut = Path.Combine(dst, "json");
                Directory.CreateDirectory(jsonOut);

                if (Directory.Exists(p))
                {
                    foreach (var path in Directory.EnumerateFiles(p))
                    {
                        Write(jsonOut, path, true);
                    }
                    Console.WriteLine("Success!");
                }
                else if (File.Exists(p))
                {
                    Write(jsonOut, p, true);
                    Console.WriteLine("Success!");
                }
            }
        }
    }
}