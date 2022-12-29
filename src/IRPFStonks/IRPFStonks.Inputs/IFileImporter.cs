namespace IRPFStonks.Inputs
{
    public interface IFileImporter<T> where T : class, IEquatable<T>
    {
        Task<ImportResult<T>> ImportFileAsync(string filePath);
    }
}
