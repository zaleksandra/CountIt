namespace CountIt.Services
{
    public interface IDocumentService
    {
        Dictionary<string, int> CountUniqueWords(string input);
    }
}
