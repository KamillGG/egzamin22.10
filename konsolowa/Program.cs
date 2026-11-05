

using System;

string[] big = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
string[] diacritics = ["ą", "ę", "ł", "ń", "ó", "ś", "ż", "ź", "Ą", "Ę", "Ł", "Ń", "Ó", "Ś", "Ż", "Ź"];
string[] digits = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
string[] small = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
string[] specials = ["!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+"];
Random random = new Random();
//nazwa funkcji: Main
//opis funkcji: funkcja glowna ktora wywoluje generowanie hasla
//parametry: brak
//zwracany typ i opis: pass = hasło wygenerowane (string)
//autor: 12345678910
string Main()
{
    int length = 12;
    string pass = "";
    int[] bannedIndex = new int[length];
    int numberOfThings = 0;
    for (int i = 0; i < length; i++)
    {
        pass += "0";
    }
    //bigLetters
    for (int i = 0;i < 3; i++)
    {
        string element = getElement(big);
        int rand = randomIndex(bannedIndex, length);
        pass  = ReplaceAt(pass,rand, Convert.ToChar(element));
        bannedIndex[numberOfThings] = rand+1;
        numberOfThings++;
    }
    for (int i = 0; i< 3; i++)
    {
        string element = getElement(small);
        int rand = randomIndex(bannedIndex, length);
        pass = ReplaceAt(pass, rand, Convert.ToChar(element));
        bannedIndex[numberOfThings] = rand+1;
        numberOfThings++;
    }
    for (int i = 0; i < 2; i++)
    {
        string element = getElement(digits);
        int rand = randomIndex(bannedIndex, length);
        pass = ReplaceAt(pass, rand, Convert.ToChar(element));
        bannedIndex[numberOfThings] = rand+1;
        numberOfThings++;
    }
    for (int i = 0; i < 2; i++)
    {
        string element = getElement(specials);
        int rand = randomIndex(bannedIndex, length);
        pass = ReplaceAt(pass, rand, Convert.ToChar(element));
        bannedIndex[numberOfThings] = rand+1;
        numberOfThings++;
    }
    for (int i = 0; i < 2; i++)
    {
        string element = getElement(diacritics);
        int rand = randomIndex(bannedIndex, length);
        pass = ReplaceAt(pass, rand, Convert.ToChar(element));
        bannedIndex[numberOfThings] = rand+1;
        numberOfThings++;
    }
    return pass;
}
//nazwa funkcji: ReplaceAt
//opis funkcji: podmienia znak w string na podanym indexie
//parametry: input = podany string
//index = index w ktorym bedzie wstawiony newChar
// newChar = nowy znak do wstawienia
//zwracany typ i opis: zwraca zmieniony string (string)
//autor: 12345678910
string ReplaceAt(string input, int index, char newChar)
{
    if (input == null)
    {
        throw new ArgumentNullException("input");
    }
    char[] chars = input.ToCharArray();
    chars[index] = newChar;
    return new string(chars);
}
//nazwa funkcji: randomIndex
//opis funkcji: wybiera losowy niezajęty index tablicy
//parametry: bannedIndex = zajęte indexy
// targetLength = docelowa dlugosc hasla
//zwracany typ i opis: zwraca losowy index (int)
//autor: 12345678910
int randomIndex(int[] bannedIndex, int targetLength)
{
    int rand = random.Next(0, targetLength);
    while (true)
    {
        bool check = false;
        foreach (var item in bannedIndex)
        {
            if(item == rand+1)
            {
                rand = random.Next(0, targetLength);
                check = true;
            }
        }
        if (check)
        {
            continue;
        }
        else
        {
            break;
        }
    }
    return rand;
}
//nazwa funkcji: getElement
//opis funkcji: losuje element z podanej tablicy
//parametry: signs = tablica z elemntami
//zwracany typ i opis: zwraca losowy element (string)
//autor: 12345678910
string getElement(string[] signs)
{
    string randomChar = signs[random.Next(signs.Length)];
    return randomChar;
}
for (int i = 0; i < 5; i++) {
    Console.WriteLine("Hasło "+(i+1)+": "+ Main()); 
}