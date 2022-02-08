using UnityEngine;

public struct Question
{
    public string operatorText;
    public int value1;
    public int value2;
    public int answer;

    public Question(string operatorText, int value1, int value2, int answer)
    {
        this.operatorText = operatorText;
        this.answer = answer;
        this.value1 = value1;
        this.value2 = value2;
    }
}

public static class Helpers
{
    public static int GetRandomNumber(int maxValue, int minValue = 0)
    {
        var f = Random.Range(minValue, maxValue);
        return f;
    }


    public static Question GetQuestion()
    {
        int value1 = 0;
        int value2 = 0;
        string operatorText = "+";
        int answer = 0;

        switch (GetRandomNumber(3))
        {
            case 0:
                value1 = GetRandomNumber(90, 2);
                value2 = GetRandomNumber(90, 2);
                answer += AddNumbers(value1, value2);
                operatorText = "+";
                break;

            case 1:
                value1 = GetRandomNumber(90, 2);
                value2 = GetRandomNumber(value1, 2);
                answer += SubtractNumbers(value1, value2);
                operatorText = "-";
                break;

            case 2:
                value1 = GetRandomNumber(90, 2);
                value2 = value1 > 20 ? GetRandomNumber(20, 2) : GetRandomNumber(90, 2);
                answer += MultiplyNumbers(value1, value2);
                operatorText = "x";
                break;

            case 3:
                value1 = GetRandomNumber(90, 2);
                value2 = value1 > 10 ? GetRandomNumber(9, 2) : GetRandomNumber(90, 2);
                answer += DivideNumbers(value1, value2);
                operatorText = "%";
                break;
        }

        var newQuestion = new Question(operatorText, value1, value2, answer);
        GameManager.CurrentQuestion = newQuestion;
        return newQuestion;
    }


    public static int AddNumbers(int value1, int value2)
    {
        return value1 + value2;
    }


    public static int SubtractNumbers(int value1, int value2)
    {
        return value1 - value2;
    }


    public static int MultiplyNumbers(int value1, int value2)
    {
        return value1 * value2;
    }


    public static int DivideNumbers(int value1, int value2)
    {
        return value1 / value2;
    }
}
