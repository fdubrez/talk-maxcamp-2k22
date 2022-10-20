use std::io::{BufRead, BufReader};
use std::net::TcpStream;

pub fn read(stream: &mut TcpStream) -> String {
    let mut buf_reader = BufReader::new(stream);

    read_response_status(&mut buf_reader);

    read_headers(&mut buf_reader);

    read_body(&mut buf_reader)
}
fn read_body(buf_reader: &mut BufReader<&mut TcpStream>) -> String{
    let mut body = String::new();
    loop {
        if read_next_chunk(buf_reader, &mut body) == 0 {
            return body;
        }
    }
}
fn read_next_chunk(buf_reader: &mut BufReader<&mut TcpStream>, body: &mut String) -> usize {
    // read the chunk size, it's in hexadecimal
    let mut line = String::new();
    buf_reader.read_line(&mut line).expect("Error while reading chunk size from response");
    let chunk_size = i64::from_str_radix(&line[0..line.len()-2], 16).unwrap();
    if chunk_size == 0 {
        return 0;
    }

    let size = buf_reader.read_line(body).expect("Error while reading line from response");
    size
}
fn read_headers(buf_reader: &mut BufReader<&mut TcpStream>) {
    let mut line = String::new();
    loop {
        buf_reader.read_line(&mut line).expect("Error while reading line from response");
        if line.to_lowercase().contains("content-length") {
            panic!("implementation is only done for chunked and not content-length yet");
        }
        if line.eq("\r\n") || line.eq("\n") {
            // end of headers
            return;
        }
        line.clear();
    }
}

fn read_response_status(buf_reader: &mut BufReader<&mut TcpStream>) {
    let mut line = String::new();
    buf_reader.read_line(&mut line).expect("Error while reading line from response");
    let status: &str = &line[9..12];
    if status != "200" {
        panic!("Error, response was not 200 but {}", status);
    }
}