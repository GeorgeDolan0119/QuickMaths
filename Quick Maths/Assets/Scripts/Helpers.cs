using System;

public struct Question
{
    public string operatorText;
    public int value1;
    public int value2;
    public double answer;

    public Question(string operatorText, int value1, int value2, double answer)
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
        var f = UnityEngine.Random.Range(minValue, maxValue);
        return f;
    }


    public static Question GetQuestion()
    {
        Question newQuestion = new Question();

        switch (GetRandomNumber(4))
        {
            case 0:
                newQuestion = GetAdditionQuestion();
                break;

            case 1:
                newQuestion = GetSubtractionQuestion();
                break;

            case 2:
                newQuestion = GetMultiplicationQuestion();
                break;

            case 3:
                newQuestion = GetDivisionQuestion();
                break;
        }

        GameManager.CurrentQuestion = newQuestion;
        return newQuestion;
    }


    private static int AddNumbers(int value1, int value2)
    {
        return value1 + value2;
    }

    private static Question GetAdditionQuestion()
    {
        int value1 = GetRandomNumber(90, 2);
        int value2 = GetRandomNumber(90, 2);
        int answer = AddNumbers(value1, value2);

        return new Question("+", value1, value2, answer);
    }


    private static int SubtractNumbers(int value1, int value2)
    {
        return value1 - value2;
    }

    private static Question GetSubtractionQuestion()
    {
        int value1 = GetRandomNumber(90, 2);
        int value2 = GetRandomNumber(value1, 2);
        int answer = SubtractNumbers(value1, value2);

        return new Question("-", value1, value2, answer);
    }


    private static int MultiplyNumbers(int value1, int value2)
    {
        return value1 * value2;
    }

    private static Question GetMultiplicationQuestion()
    {
        int value1 = GetRandomNumber(90, 2);
        int value2 = value1 > 20 ? GetRandomNumber(20, 2) : GetRandomNumber(90, 2);
        int answer = MultiplyNumbers(value1, value2);

        return new Question("×", value1, value2, answer);
    }


    private static Question GetDivisionQuestion()
    {
        int value1 = GetRandomNumber(90, 2);
        int value2;

        if (value1 > 10)
        {
            value2 = GetRandomNumber(10, 2);
        }
        else
        {
            value2 = GetRandomNumber(value1, 2);
        }

        double answer = DivideNumbers(value1, value2);
        answer = Math.Round(answer, 2);

        return new Question("÷", value1, value2, answer);
    }

    private static double DivideNumbers(int value1, int value2)
    {
        return (double)value1 / value2;
    }
}
