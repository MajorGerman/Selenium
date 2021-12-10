using Framework.Logging;
using NUnit.Framework;

namespace Framework {
    public class FW {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static Logger Log => _logger ?? throw new NullReferenceException("Logger is Null!");
        
        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        private static Logger _logger;

        public static DirectoryInfo CreateOutputDirectory() {
            var testDirectory = WORKSPACE_DIRECTORY + "output";

            if (Directory.Exists(testDirectory)) {
                Directory.Delete(testDirectory, recursive : true);
            }
            
            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetLogger() {
            var OutputDir = WORKSPACE_DIRECTORY + "/output";
            var TestName = TestContext.CurrentContext.Test.Name;
            var FullPath = $"{OutputDir}/{TestName}";

            CurrentTestDirectory = Directory.CreateDirectory(FullPath);
            _logger = new Logger(TestName, CurrentTestDirectory.FullName + "/log.txt");
        }
    }


}