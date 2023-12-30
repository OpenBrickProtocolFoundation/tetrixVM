enum OpCode {
    Game = 0x01
    Input = 0x02
    Flow = 0x03
    Data = 0x04
}

enum GameMode {
    start = 0x01
    stop = 0x02
    restart = 0x03
}

enum InputDirection {
    left = 0x01
    right = 0x02
    drop = 0x03
    down = 0x04
}

macro input dir {
    db Input
    db dir
}

macro game mode {
    db Game
    db mode
}