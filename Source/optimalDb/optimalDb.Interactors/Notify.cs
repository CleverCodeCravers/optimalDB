namespace optimalDb.Interactors;

public delegate void Notify();

public delegate void Notify<in T>(T value);