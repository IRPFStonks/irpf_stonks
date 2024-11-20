namespace IRPFStonks.Inputs
{
    public class FileImporterFactory<T> where T : class, IEquatable<T>
    {
        private IFileImporter<T> fileImporter;

        public FileImporterFactory(IFileImporter<T> importer)
        {
            fileImporter = importer;
        }

        public async Task<ImportResult<T>> ImportFileAsync(string filePath)
        {
            return await fileImporter.ImportFileAsync(filePath).ConfigureAwait(false) ;
        }
    }
}
