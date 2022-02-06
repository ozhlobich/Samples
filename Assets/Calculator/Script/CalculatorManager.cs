using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public enum InputStates
    {
        FirstParam,
        SecondParam,
        Result
    }

    public enum Sign
    {
        Equal,
        Plus
    }

    public class CalculatorManager : MonoBehaviour
    {
        public Button[] NumberButtons;
        public Button PlusButton;
        public Button EqualButton;
        public Text output;
        private string _firstParam;
        private string _secondParam;
        private InputStates _inputStates;
        private Sing _sing;

        void Start()
        {
            for (int i = 0; i < numberButtons.Length; i++)
            {
                var i1 = i;
                numberButtons[i].onClick.AddListener(
                    () => { OnNumberButtonClick(i1); });
            }

            plusButton.onClick.AddListener(OnPlusButtonClick);
            equalButton.onClick.AddListener(OnEqualButtonClick);
        }

        private void PrintNumberOnDisplay(string number)
        {
            output.text = number;
        }

        private void OnNumberButtonClick(int number)
        {
            switch (_inputStates)
            {
                case InputStates.FirstParam:
                    _firstParam += number;
                    PrintNumberOnDisplay(_firstParam);
                    break;
                case InputStates.SecondParam:
                    _secondParam += number;
                    PrintNumberOnDisplay(_secondParam);
                    break;
                case InputStates.Result:
                    _inputStates = InputStates.FirstParam;
                    _firstParam += number;
                    PrintNumberOnDisplay(_firstParam);
                    break;

            }
        }

        private void OnPlusButtonClick()
        {
            _sign = _Sign.Plus;
            switch (_inputStates)
            {
                case InputStates.FirstParam:
                    _inputStates = InputStates.SecondParam;
                    break;
                case InputStates.SecondParam:
                    _firstParam = _secondParam;
                    break;
                case InPutStates.Result:
                    _firstParam = output.text;
                    _inputStates = InputStates.SecondParam;
                    break;
            }
        }

        private void OnEqualButtonClick()
        {
            switch (_sing)
            {
                case Sing.Plus:
                    _sing = Sing.Equal;
                    _inputStates = InputStates.Result;
                    var p1 = string.IsNullOrEmpty(_firstParam) ? 0 : Convert.ToIn32(_secondParam);
                    var p2 = string.IsNullOrEmpty(_secondParam) ? 0 : Convert.ToIn32(_secondParam);
                    var result = (p1 + p2).ToString();
                    PrintNumberOnDisplay(result);
                    break;
                case Sing.Equal:
                    break:
            }

            _firstParam = "";
            _secondParam = "";
        }

    }
}
