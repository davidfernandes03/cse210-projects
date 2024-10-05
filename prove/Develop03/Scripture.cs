public class Scripture
{
    // Attributes
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] allWords = text.Split(' ');
        foreach (string eachWord in allWords)
        {
            Word word = new Word(eachWord);
            _words.Add(word);
        }
    }

    // Methods
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";

        foreach (Word eachWord in _words)
        {
            scriptureText += eachWord.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} -> {scriptureText.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word eachWord in _words)
        {
            if (!eachWord.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}