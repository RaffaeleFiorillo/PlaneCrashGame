using System;

public class ButtonInputControllerSetup
{
    #region Properties

    // Button List

    #endregion Properties

    #region Constructor

    public ButtonInputControllerSetup(string inputSetupType)
    {
        switch (inputSetupType)
        {
            case "two-buttons":
                return new TwoButtonInputController();
            case "left-button":
                return new LeftButtonInputController();
            case "right-button":
                return new RightButtonInputController();
            case "two-bad-buttons":
                return new TwoBadButtonInputController();
            default:
                return new TwoButtonInputController();
        }
    }

    #endregion Constructor

    #region Methods

    #region Methods
}
