using System.Collections.Immutable;

namespace IRPFStonks.Inputs
{
    /// <summary>
    /// Contains the results of a file import, including if the import was successful, what error occurred and data imported if available.
    /// </summary>
    /// <typeparam name="T">Type of data from import.</typeparam>
    public class ImportResult<T> where T : class, IEquatable<T>
    {
        public ImportResult(bool isSuccessful, string importErrors, ImmutableList<T>? importedData)
        {
            IsSuccessful = isSuccessful;
            ImportErrors = importErrors;
            ImportedData = importedData;
        }
        public string ImportErrors { get; set; }
        public bool IsSuccessful { get; set; }
        public ImmutableList<T>? ImportedData { get; }

    }
}