# Projectiles
This package simplifies projectile management through an expandable, interface-driven structure, making it a versatile foundation for customizing projectile behavior in your Unity game.

The plugin provides a basic implementation of EffectFactories using ScriptableObjects since Unity doesn't natively support easy serialization of Interface lists in Inspector. You can use the ScriptableObject approach that I've implemented here, or use your implementation by using a plugin that supports serialization of interfaces, i.e. SerializableInterfaces https://github.com/Thundernerd/Unity3D-SerializableInterface, or Editor Toolbox https://github.com/arimger/Unity-Editor-Toolbox both of which I highly recommend.

You can easily extend the system by writing your custom emitters, projectiles, projectile physics, and projectile presentations. My basic implementations use Rigidbody, however, you can quickly implement other physics, i.e. 2D by implementing the IProjectilePhysics interface and controlling it i.e. by inheriting from PhysicsControllerBase.

My goal was to separate the projectile from its physics and presentation. Thanks to that you can have a projectile without presentation at all, which could be useful when you'd like to simulate something that doesn't require rendering and presentation to happen.
My other decision was to separate Projectile Presentation's GameObject from Projectile's GameObject. Why is that? 
  1. That allows for an easy workflow where you can allow a technical artist or designer to edit the presentation without worrying, that the projectile logic will break.
  2. Oftentimes when the Projectile hits the target we would like to return it to the pool/destroy it. It always causes problems with parenting and deparenting the projectile presentation. I.e. you'd expect the arrow to stick in the ground after it hits it. Or maybe your projectile leaves a trail and when you want to return the projectile to pool, the trail just disappears and produces an ugly result. By using two separate GameObjects we can return the projectile to the pool as soon as we want i.e. after hitting the target without worrying about presentation. Presentation can behave in many different ways and this separation allows for that.

You can find a basic implementation that uses the ScritpableObject effect factories and basic presentation handling in the BasicImplementationSample directory. The scene was created in URP. 
