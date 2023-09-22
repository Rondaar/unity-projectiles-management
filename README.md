# Projectiles
This package simplifies projectile management through an expandable, interface-driven structure, making it a versatile foundation for customizing projectile behavior in your Unity game.

The plugin provides a basic implementation of EffectFactories by using ScriptableObjects, since Unity doesn't natively support easy serialization of Interface lists in inspector. You can use the ScriptableObject approach that I've implemented here, or use your own implementation by using a plugin that supports serialization of interfaces, i.e. SerializableInterfaces https://github.com/Thundernerd/Unity3D-SerializableInterface, or Editor Toolbox https://github.com/arimger/Unity-Editor-Toolbox both of which I highly recommend. You can easily extend the system by writing your own custom emmiters, projectiles, projectile physics and projectile presentations. My basic implementations uses Rigidbody, however you can easily implement other physics, i.e. 2D by implementing IProjectilePhysics interface and controlling it i.e. by inheriting from PhysicsControllerBase. You can find basic implementation that makes use of the ScritpableObject effect factories in the BasicImplementationSample directory. The scene was created in URP. 
