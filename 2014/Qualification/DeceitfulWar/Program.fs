open System
open System.Collections.Generic

(*** helpers **)

let readString () = Console.ReadLine()

let parseIntegers (s : string) =
    s.Split(' ') |> Array.map int
    
let parseDoubles (s: string) =
    s.Split(' ') |> Array.map double

let readIntegers () = 
    readString () |> parseIntegers

let readDoubles () =
    readString () |> parseDoubles

let readInteger () = (readIntegers ()).[0]

[<EntryPoint>]
let main argv = 
    let numTests = readInteger()
    for i in [1..numTests] do
        let blocksCount = readInteger()
        let naomiBlocks = readDoubles()
        let kenBlocks = readDoubles()
        printfn "Case #%d:" i
    0 // return an integer exit code
