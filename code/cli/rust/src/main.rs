mod reader;

use std::{env, fs};
use std::io::{Write, Error};
use std::net::TcpStream;
use std::time::Instant;
use base64::{encode, decode};

fn main() -> std::result::Result<(), Error>{
    let start = Instant::now();
    //get file and convert to base64
    let args: Vec<String> = env::args().collect();
    let contents = fs::read(args.get(1).unwrap()).expect("Should have been able to read the file");
    let image_b64 = encode(contents);

    //start connection
    let mut sender = TcpStream::connect("127.0.0.1:8080")?;

    //prepare request
    let request = prepare_request(image_b64);

    //send the request
    sender.write_all(request.as_bytes())?;

    let response_body = reader::read(&mut sender);
    write_file_from_body(response_body);

    let elapsed = start.elapsed();
    println!("Elapsed: {:.2?}", elapsed);
    Ok(())
}

fn prepare_request(image_b64: String) -> String {
    let mut body = String::from("{\"image\": \"");
    body.push_str(image_b64.as_str());
    body.push_str("\"}");

    let mut request = format!("POST /kissme HTTP/1.1\r\nHost: localhost:8080\r\nContent-Type: application/json\r\nContent-Length: {}\r\n\r\n", body.len());
    request.push_str(body.as_str());
    request
}

fn write_file_from_body(body: String) {
    println!("{}", &body[0..50]);
    // get base64 part.
    // take data between {"image":"data:image/png;base64,  and "\r\n}
    let (_, base64_start) = body.split_once(",").unwrap();
    let (base64_image,_) = base64_start.split_once("\"").unwrap();

    // decode and save file
    let content = decode(base64_image).expect("Error while decoding");
    fs::write("./output.png", content).expect("Could not write file");
}