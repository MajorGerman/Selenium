namespace Framework.Logging {
    public class Logger {
        private readonly string _filepath;

        public Logger (string testName, string filepath) {
            _filepath = filepath;

            using(var log = File.CreateText(_filepath)) {
                log.WriteLine($" --------------------------------------- ");
                log.WriteLine($"     Test: {testName} ");
                log.WriteLine($"     Timestamp: {DateTime.Now.ToLocalTime()} ");
                log.WriteLine($" --------------------------------------- ");
            }
        }

        public void Info (string message) {
            WriteLine($"[INFO]: {message}");
        }

        public void Step (string message) {
            WriteLine($"    [STEP]: {message}");
        }

        public void Warning (string message) {
            WriteLine($"[WARNING]: {message}");
        }

        public void Error (string message) {
            WriteLine($"[ERROR]: {message}");
        }

        public void Fatal (string message) {
            WriteLine($"[FATAL]: {message}");
        }


        private void WriteLine (string text) {
            using (var log = File.AppendText(_filepath)) {
                log.WriteLine(text);
            }
        }

        private void Write (string text) {
            using (var log = File.AppendText(_filepath)) {
                log.Write(text);
            }
        }
    }
}