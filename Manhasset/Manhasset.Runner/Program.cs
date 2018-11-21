using System;
using System.Threading.Tasks;

namespace Manhasset.Runner
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Too few arguments");
                Console.WriteLine("Required areguments are:");
                Console.WriteLine(" - path to yaml file");
                Console.WriteLine(" - name of target project");
                Console.WriteLine(" - directory of repo");
                return 1;
            }
            var pathToYaml = args[0];
            var targetProjectName = args[1];
            var rootDirectory = args[2];
            var generation = new Manhasset.Generator.Generator(pathToYaml, targetProjectName, rootDirectory);
            generation.RunGeneration();
            return 0;
        }
    }
}
