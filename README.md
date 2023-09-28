# Coin Runner
Sorry, I dont have enogh space in my Git LFS so here is the link to the build: https://drive.google.com/file/d/1yb0OU5SLbmD1sqrpcRIHZvQJz-CWKneq/view?usp=sharing

### Used Packages
- DOTween
- UniTask
- SimpleInput

### Used Patterns
- Service Locator
- State Machine
- Strategy
---

This project is based on Component and Service architecture.

The flow of the game starts in the ```GameBootstrap``` class that creates ```Game State Machine```. The Game State machine's goal is to control the flow of the game. The State machine pattern comes in handy when we need to sequentially do some things. In terms of this game states are:
- Bootstrap State (The state that registers services in Service Locator)
- LoadScene State (The state that instantiates and constructs an object that we need in the game)
- GameLoop
<img width="800" alt="image" src="https://github.com/maxvone/coin-runner/assets/60828878/46d1f31c-b9ed-4f77-9c37-66f52bb9be55">

Another important thing to discuss is the ```Service Locator``` pattern. It's the Dependency Injection implementation. I thought importing Zenject or some kind of DI framework would be bloated for such a small project, so I've decided to use the manual-written one.
The game uses the concept of ```Services```. Services are objects that handle one responsibility of a game. For example in the game you will find:
- Input Service
- Game Factory Service
- Asset Provider Service
- Static Data Service
- etc.

You can look at the work of service mostly in GameFactory, which is the Service that creates objects for the game and constructs them (passing them needed reference e.g.)

--- 
Different behavior of pickupables is made with the help of **Strategy pattern**:
```
public class SlowDownSpeedEffect : IEffectStrategy
{
    public string Text => "- Speed";
    private IMovementAreaDataHandlerService _movementAreaDataHandlerService;

    public SlowDownSpeedEffect(IMovementAreaDataHandlerService movementAreaDataHandlerService) =>
        _movementAreaDataHandlerService = movementAreaDataHandlerService;

    public async void Execute()
    {
        _movementAreaDataHandlerService.MovementAreaMove.Speed /= 2;  
        await UniTask.Delay(10000);
        _movementAreaDataHandlerService.MovementAreaMove.Speed *= 2;
    }
}
```
<img width="218" alt="image" src="https://github.com/maxvone/coin-runner/assets/60828878/e0848612-ca68-42d1-a285-cbacf7a2bbfe">

The Strategy is assigned when Pickupables are created in the Game Factory according to static data gathered from the scene.

---

This architectural approach allows you to add features with maximum speed respecting SRP and other SOLID principles.



