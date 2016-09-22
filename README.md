# PillarVendingKata
Vending machine kata done in c#


Thoughts:

In the case where there are multiple similar test cases (different coin sizes/weights) that all use the same code path, is it worth testing each one to make sure it works? The code, to me at least, is self explanatory in that any case covered by the dictionary will return true and anything outside that will return false. This seems like valid coverage to me, but is test coverage more about me validating my code or someone else knowing that every base is covered?

I’m also unsure about how to handle things like needing to refactor for console use. It is something that comes up in the prompt but doesn’t really require further testing, just refactoring (in this case to use string inputs instead of just integers). Is this part of the Red, Green, Refactor process or am I not doing this quite right?

Do you test public and private functions, or do you test the public facing members and if they return the correct results assume the internals are functioning as expected?

So TDD is all about doing the least amount of coding possible to green light a test. During the refactor step or even when you’re writing future test, when is the best time (if ever) to refactor old tests to take new functionality into account?

I had a bit of a zen moment when testing to make sure that any amount over the purchase amount was returned. I had already written the functionality and was able to get that entire feature segment working with adding one line of code.