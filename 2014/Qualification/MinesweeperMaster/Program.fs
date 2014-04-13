open System
open System.Collections.Generic

(*** helpers **)

let readString () = Console.ReadLine()

let parseIntegers (s : string) =
    s.Split(' ') |> Array.map int
    
let readIntegers () = 
    readString () |> parseIntegers

let readInteger () = (readIntegers ()).[0]

let expand l size value = 
    let len = List.length l
    if size > len then List.append (List.replicate (size-len) value) l
    else l

let bombsPerRow c maxb = seq { for i = c downto 1 do if i <= maxb && i <> c-1 then yield i } 
let bombsPerLastRow c maxb = bombsPerRow c maxb |> Seq.map (fun(x) -> x*2)

let deduplicate = function
        | n::rest -> n/2 :: n/2 :: rest
        | [] -> [0]

let rec iterateBombsOnRow r c m currow maxb placed = 
    if m = 0 then expand placed r 0 |> deduplicate |> List.rev |> Some (* solved *)
    else if currow > r || m < 0 then None               (* no solution *)
    else
        let bombs = if currow = r then bombsPerLastRow c maxb
                                  else bombsPerRow c maxb
        try
            bombs |> Seq.pick (fun(b) -> iterateBombsOnRow r c (m-b) (currow+1) b (b::placed)) |> Some
        with
            | :? KeyNotFoundException -> None

let printBoard r c solution =
    let printRow mines click =
        for i=1 to c do
            if i <= mines then printf "*"
            else if i = c && click then printf "c"
            else printf "."
        printfn ""
    let processRow row mines = printRow mines (row=r)
    List.iter2 processRow [1..r] solution

let fullBoard r c =
    seq { for i = 1 to r do if i=r then yield c-1 else yield c } |> Seq.toList

let solveBoard r c m =
    if r=1 then printBoard r c [m]
    else if r*c = m+1 then printBoard r c (fullBoard r c)
    else if m = r*c - 2 then printfn "Impossible"
    else
        match iterateBombsOnRow (r-1) c m 1 c [] with
            | Some solution -> printBoard r c solution
            | None -> printfn "Impossible"

[<EntryPoint>]
let main argv = 
    let numTests = readInteger()
    for i in [1..numTests] do
        let [| r; c; m |] = readIntegers()
        printfn "Case #%d:" i
        solveBoard r c m
    0 // return an integer exit code
