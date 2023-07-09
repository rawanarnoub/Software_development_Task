namespace WebApplication4.Logging
{
    public static class Log
    {
        public static void logInfo(string ex)
        {
            var directory = Directory.GetCurrentDirectory();
            var path = Path.Combine(directory, "Logs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText($"{path}\\{Guid.NewGuid().ToString()}.txt", ex.ToString());
        }
    }
}
