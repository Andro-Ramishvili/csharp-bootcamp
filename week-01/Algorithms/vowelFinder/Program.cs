// Display messge:
Console.Write("Enter the sentence: ");

// Input sentence:
string sentence = (Console.ReadLine() ?? string.Empty).ToLower();
int vowelCount = 0;
// Find each letter in the sentence:
foreach (char letter in sentence)
{
    if(letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
    {
        vowelCount++;
    }
}

Console.WriteLine($"The number of vowels in the sentence is: {vowelCount}");    