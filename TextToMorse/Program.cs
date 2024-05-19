namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator translator = new Translator();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Translate text to Morse code");
                Console.WriteLine("2. Translate Morse code to text");
                Console.WriteLine("3. Exit");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("Enter text to translate to Morse code:");
                    string input = Console.ReadLine();
                    string morseCode = translator.TextToMorse(input);
                    Console.WriteLine($"Morse Code: {morseCode}");
                }
                else if (option == "2")
                {
                    Console.WriteLine("Enter Morse code to translate to text (use spaces between letters and '|' between words):");
                    string input = Console.ReadLine();
                    string text = translator.MorseToText(input);
                    Console.WriteLine($"Text: {text}");
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }

    public class Translator
    {
        private readonly Dictionary<char, string> textToMorse;
        private readonly Dictionary<string, char> morseToText;

        public Translator()
        {
            textToMorse = new Dictionary<char, string>
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
                {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
                {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
                {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
                {'Z', "--.."}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
                {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
                {'0', "-----"}, {' ', "/"}
            };

            morseToText = new Dictionary<string, char>();
            foreach (var pair in textToMorse)
            {
                morseToText[pair.Value] = pair.Key;
            }
        }

        public string TextToMorse(string text)
        {
            text = text.ToUpper();
            List<string> morseCode = new List<string>();

            foreach (char c in text)
            {
                if (textToMorse.ContainsKey(c))
                {
                    morseCode.Add(textToMorse[c]);
                }
                else
                {
                    morseCode.Add("?");
                }
            }

            return string.Join(" ", morseCode);
        }

        public string MorseToText(string morse)
        {
            string[] morseWords = morse.Split('|');
            List<string> words = new List<string>();

            foreach (string morseWord in morseWords)
            {
                string[] morseChars = morseWord.Trim().Split(' ');
                List<char> textChars = new List<char>();

                foreach (string morseChar in morseChars)
                {
                    if (morseToText.ContainsKey(morseChar))
                    {
                        textChars.Add(morseToText[morseChar]);
                    }
                    else
                    {
                        textChars.Add('?');
                    }
                }

                words.Add(new string(textChars.ToArray()));
            }

            return string.Join(" ", words);
        }
    }
}
