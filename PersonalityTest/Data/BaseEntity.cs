﻿namespace PersonalityTest.Data;

public abstract class BaseEntity<TKey>
{
    public virtual TKey Id { get; set; }
}
