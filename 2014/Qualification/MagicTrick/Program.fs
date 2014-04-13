open System
open System.Collections.Generic

(*** helpers **)

let readString () = Console.ReadLine()

let parseIntegers (s : string) =
    s.Split(' ') |> Array.map int
    
let readIntegers () = 
    readString () |> parseIntegers

let readInteger () = (readIntegers ()).[0]

[<EntryPoint>]
let main argv = 
    let numTests = readInteger()
    for i in [1..numTests] do
        let firstChoice = readInteger()
        let firstBoard = seq { for i in [1..4] do yield readIntegers() } |> Seq.toArray
        let secondChoice = readInteger()
        let secondBoard = seq { for i in [1..4] do yield readIntegers() } |> Seq.toArray

        let firstSet = firstBoard.[firstChoice-1] |> Set.ofArray
        let secondSet = secondBoard.[secondChoice-1] |> Set.ofArray
       
        match Set.intersect firstSet secondSet |> Set.toList with
            | [x] -> printfn "Case #%d: %d" i x
            | []  -> printfn "Case #%d: Volunteer cheated!" i
            | _   -> printfn "Case #%d: Bad magician!" i
    0 // return an integer exit code
