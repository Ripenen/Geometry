using Base.Scripts;
using ExtensionsApi;

public abstract class HandlerDecorator : Handler
{
    private readonly Handler _handler;

    protected HandlerDecorator(Handler handler)
    {
        _handler = handler;
    }

    public override void Handle(Cube cube)
    {
        _handler.Handle(cube);
    }

    public override void Handle(Circle circle)
    {
        _handler.Handle(circle);
    }
}