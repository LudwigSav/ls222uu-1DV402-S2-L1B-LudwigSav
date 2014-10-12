using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _1DV402.S2.L1B
{
    public class SecretNumber
    {
        private int[] _guessedNumbers;
        private int _number;
        private bool _canMakeGuess;
        public const int MaxNumberOfGuesses = 7;
        public SecretNumber()
        {
            _guessedNumbers = new int[7];
            Initialize();
        }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
        public bool CanMakeGuess
        {
            get
            {
                if (Count >= MaxNumberOfGuesses || _canMakeGuess == false) { return false; }
                else { return true; }
            }
            private set
            {
                _canMakeGuess = value;
            }
        }
        public int Count { get; private set; }
        public int GuessesLeft
        {
            get
            {
                return MaxNumberOfGuesses - Count;
            }
        }
        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);
            Random random = new Random();
            Number = random.Next(1,101);
            CanMakeGuess = true;
            Count = 0;
        }
        public bool MakeGuess(int number)
        {
            if (Count >= 7)
            {
                throw new ApplicationException();
            }
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            foreach (int guessedNumber in _guessedNumbers)
            {
                if (number == guessedNumber)
                {
                    Console.WriteLine("Du har redan gissat på {0}. Gör om din gissning!", number);
                    return false;
                }
            }
            _guessedNumbers[Count] = number;
            Count++;
            if (number == Number)
            {
                Console.WriteLine("Rätt gissat! Du klarade det på {0} försök.", Count);
                CanMakeGuess = false;
                return true;
            }
            else
            {
                if (number < Number)
                {
                    Console.Write("{0} är för lågt. ", number);
                }
                else
                {
                    Console.Write("{0} är för högt. ", number);
                }
                Console.WriteLine("Du har {0} gissningar kvar.", GuessesLeft);
                return false;
            }
        }
    }
}