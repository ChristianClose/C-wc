using System.Text.RegularExpressions;

namespace wc_app;

public class Wc
{
    public string[] Commands;
    public string FileName;
    public byte[] Input;
    public string Text;

    public Wc(string[] args)
    {
        Commands = args;
        RunCommand();
    }

    public void RunCommand()
    {
        if (Commands.Length == 0) return;
        if (Commands.Length > 1)
            FileName = Commands[1];
        if (Commands.Length == 1)
            FileName = Commands[0];
        if (File.Exists(FileName))
        {
            Input = File.ReadAllBytes(FileName);
            Text = System.Text.Encoding.Default.GetString(Input);
        }

        switch (Commands[0])
        {
            case "-c":
                Console.WriteLine($"{NumberOfBytes()} {FileName}");
                break;
            case "-l":
                Console.WriteLine($"{NumberOfLines()} {FileName}");
                break;
            case "-w":
                Console.WriteLine($"{NumberOfWords()} {FileName}");
                break;
            case "-m":
                Console.WriteLine($"{NumberOfCharacters()} {FileName}");
                break;
            default:
                Console.WriteLine($"{NumberOfLines()} {NumberOfWords()} {NumberOfBytes()} {FileName}");
                break;
        }
    }

    public string NumberOfBytes()
    {
        return Input.Length.ToString();
    }

    public string NumberOfLines()
    {
        var numOfLines = Text.Split('\n').Length - 1;

        return numOfLines.ToString();
    }

    public string NumberOfWords()
    {
        int numOfWords = 0;
        var isSpace = false;
        foreach (var t in Text)
        {
            if (char.IsWhiteSpace(t))
            {
                if (!isSpace)
                {
                    numOfWords++;
                }

                isSpace = true;
            }
            else
            {
                isSpace = false;
            }
        }

        return numOfWords.ToString();
    }

    public string NumberOfCharacters()
    {
        return Text.Length.ToString();
    }
}