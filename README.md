# LanguageExt.UnitTesting
Extension methods to simplify writing unit tests for code written using LanguageExt library. These extension methods throw an exception if expectation fails.

Avalable as [LanguageExt.UnitTesting](https://www.nuget.org/packages/LanguageExt.UnitTesting/ "nuget package url") nuget package.

## Option
* ```ShouldBeSome<T>(Action<T> someValidation)```
* ```ShouldBeNone<T>()```
```C#
Option<int> subject = UnitUnderTest();

// the following line throws an exception if subject is Option<int>.None 
// or the integer value wrapped by Some does not equal 5
subject.ShouldBeSome(some => Assert.Equal(5, some));

// the following line throws an exception if subject is not Option<int>.None
subject.ShouldBeNone();
```

## Validation
* ```ShouldBeSuccess<TFail, TSuccess>(Action<TSuccess> successValidation)```
* ```ShouldBeFail<TFail, TSuccess>(Action<IEnumerable<TFail>> failValidation)```
```C#
Validation<string, int> subject = UnitUnderTest();

// the following line throws an exception if subject represents failure
// or in case of successful validation the integer value does not equal 5
subject.ShouldBeSuccess(success => Assert.Equal(5, success));

// the following line throws an exception if subject does not represent failed validation
// or in case of failed validation the failure value does not meet expectation
subject.ShouldBeFail(errors => Assert("value is not valid", errors.First()));
```

## Either
* ```ShouldBeRight<TLeft, TRight>(Action<TRight> rightValidation)```
* ```ShouldBeLeft<TLeft, TRight>(Action<TLeft> leftValidation)```
```C#
Either<string, int> subject = UnitUnderTest();

// the following line throws an exception if subject represents left side of Either
// or in case of right side of Either when the integer value does not equal 5
subject.ShouldBeRight(right => Assert.Equal(5, right));

// the following line throws an exception if subject represents right side of Either
// or in case of left side of Either when the string value does not equal "abcd"
subject.ShouldBeLeft(left => Assert.Equal("abcd", left));
```


## EitherAsync
* ```ShouldBeRight<TLeft, TRight>(Action<TRight> rightValidation)```
* ```ShouldBeLeft<TLeft, TRight>(Action<TLeft> leftValidation)```
```C#
EitherAsync<string, int> subject = UnitUnderTest();

// the following line throws an exception if subject represents left side of Either
// or in case of right side of Either when the integer value does not equal 5
await subject.ShouldBeRight(right => Assert.Equal(5, right));

// the following line throws an exception if subject represents right side of Either
// or in case of left side of Either when the string value does not equal "abcd"
await subject.ShouldBeLeft(left => Assert.Equal("abcd", left));
```

## Try
* ```ShouldBeSuccess<T>(Action<T> successValidation)```
* ```ShouldBeFail<T>(Action<Exception> failValidation)```
```C#
Try<int> subject = UnitUnderTest();

// the following line throws an exception if subject represents failure
// or in case of successful try the integer value does not equal 5
subject.ShouldBeSuccess(success => Assert.Equal(5, success));

// the following line throws an exception if subject does not represent failure
// or in case of failure the exception has wrong message
subject.ShouldBeFail(ex => Assert.Equal("something went wrong", ex.Message));
```

## TryAsync
* ```ShouldBeSuccess<T>(Action<T> successValidation)```
* ```ShouldBeFail<T>(Action<Exception> failValidation)```
```C#
TryAsync<int> subject = UnitUnderTest();

// the following line throws an exception if subject represents failure
// or in case of successful try the integer value does not equal 5
await subject.ShouldBeSuccess(success => Assert.Equal(5, success));

// the following line throws an exception if subject does not represent failure
// or in case of failure the  exception has wrong message
await subject.ShouldBeFail(ex => Assert.Equal("something went wrong", ex.Message));
```

## TryOptionAsync
* ```ShouldBeSome<T>(Action<T> someValidation)```
* ```ShouldBeNone<T>()```
* ```ShouldBeFail<T>(Action<Exception> failValidation)```
```C#
TryOptionAsync<int> subject = UnitUnderTest();

// the following line throws an exception if subject represents failure or Option<T>.None
// or the integer value wrapped by Some does not equal 5
await subject.ShouldBeSome(some => Assert.Equal(5, some));

// the following line throws an exception if subject is not Option<int>.None
await subject.ShouldBeNone();

// the following line throws an exception if subject does not represent failure
// or in case of failure the exception has wrong message
await subject.ShouldBeFail(ex => Assert.Equal("something went wrong", ex.Message));
```
