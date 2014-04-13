-module(problemA_1B).
-compile([export_all]).


readIntegers() ->
    Line = string:strip(io:get_line(""), right, $\n),
    Tokens = string:tokens(Line, " "),
    lists:map(fun(S) -> {I,_} = string:to_integer(S), I end, Tokens).
 
readString() -> io:get_line("").


for_iter(I, Total, F) when I > Total -> Total;
for_iter(I, Total, F) -> F(I), for_iter(I+1, Total, F).

for_iter(Count, F) -> for_iter(1, Count, F).
    

for_map(I, Total, F) when I > Total -> [];
for_map(I, Total, F) -> [F(I) | for_map(I+1, Total, F)].
    
for_map(Total, F) -> for_map(1, Total, F).


main() ->   
    [TestsCount] = readIntegers(),
    for_iter(TestsCount, fun solve/1).
    

solve(TestIndex) ->
    [ExistingCount, NeededCount] = readIntegers(),
    ExistingDirs = for_map(ExistingCount, fun(_) -> readString () end),
    NeededDirs = for_map(NeededCount, fun (_) -> readString () end),
    io:format("Case #~w: ~w~n", [TestIndex, "NO"]).
    