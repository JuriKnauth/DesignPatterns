using UnityEngine;

namespace DesignPatterns.Creationals.Builders
{
    public static class A
    {
        public static Builder Buildable => new();
    }

    public class Builder
    {
        private object[] _parameters;

        public Buildable Build()
        {
            return new Buildable(_parameters);
        }

        public Builder With(params object[] parameters)
        {
            _parameters = parameters;
            return this;
        }

        public static implicit operator Buildable(Builder builder)
        {
            return builder.Build();
        }
    }

    public class Buildable
    {
        private readonly object[] _parameters;

        public Buildable(params object[] parameters)
        {
            _parameters = parameters;
        }
    }

    public class Test
    {
        public Test()
        {
            _ = A.Buildable.With(new Object());
        }
    }
}