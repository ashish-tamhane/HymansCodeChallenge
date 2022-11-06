# HymansCodeChallenge

Code summary:

1. Test driven development style is followed for the refactoring and new features.
2. Individual projects are added each for BaggageCalculator, Entities, FlightProceedCheck, LoyaltlyPointsCalculator, ProfitCalculator etc. This is done so as to keep code separation and clean coding guidelines.
3. Dependency injection technique is followed. MOQ can also be used over here in order to mock data but since this example does not depend on any external depedency it is not used.


Input sets for various outputs are as follows:
1. Default test
add general Steve 30 
add general Mark 12 
add general James 36 
add general Jane 32 
add loyalty John 29 1000 true 
add loyalty Sarah 45 1250 false 
add loyalty Jack 60 50 false 
add airline Trevor 47 
add general Alan 34 
add general Suzy 21 
view ruleset

print summary

2. More airline employees with Default ruleset. The flight should not proceed as the Default ruleset is used.
add airline Steve 30 
add airline Mark 12 
add airline James 36 
add airline Jane 32 
add airline John 29 
add airline Sarah 45 
add airline Jack 60 
add airline Trevor 47
add airline Trevor 47 
add airline Trevor 47 
add general Alan 34 
add general Suzy 21 
default
print summary

3. More airline employees with Relaxed ruleset. The flight should  proceed as the Relaxed ruleset is used.
add airline Steve 30 
add airline Mark 12 
add airline James 36 
add airline Jane 32 
add airline John 29 
add airline Sarah 45 
add airline Jack 60 
add airline Trevor 47
add airline Trevor 47 
add airline Trevor 47 
add general Alan 34 
add general Suzy 21 
relaxed
print summary

4. Different aircraft selection test with Relaxed ruleset.
add airline Steve 30
add airline Steve 30 
add airline Mark 12 
add airline James 36 
add airline Jane 32 
add airline John 29 
add airline Sarah 45 
add airline Jack 60 
add airline Trevor 47
add airline Trevor 47 
add airline Trevor 47 
add general Alan 34 
add general Suzy 21 
relaxed
print summary

5. Different aircraft selection test with Default ruleset.
add airline Steve 30
add airline Steve 30 
add airline Mark 12 
add airline James 36 
add airline Jane 32 
add airline John 29 
add airline Sarah 45 
add airline Jack 60 
add airline Trevor 47
add airline Trevor 47 
add airline Trevor 47 
add general Alan 34 
add general Suzy 21 
default
print summary

6. Too many passengers with Default ruleset.
add airline Steve 30
add airline Steve 30 
add airline Mark 12 
add airline James 36 
add airline Jane 32 
add airline John 29 
add airline Sarah 45 
add airline Jack 60 
add airline Trevor 47
add airline Trevor 47 
add airline Trevor 47 
add general Alan 34 
add general Suzy 21 
add general Alan 34 
add general Suzy 21 
add general Alan 34 
add general Suzy 21 
add general Alan 34 
add general Suzy 21 
add general Alan 34 
add general Suzy 21 
relaxed
print summary