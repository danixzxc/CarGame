using Tools;

public class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();
        
        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);
        
        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);//здесь заменить на джойстик
        //var joystickView = new InputJoystickView();
        //AddController(joystickView);
        //BaseInputView.Init(joystickView);
            
        var carController = new CarController();
        AddController(carController);
    }
}

