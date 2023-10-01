# Analysis of server logs

## Definition
- You have been given the access.log of one of [NASA's servers](https://drive.google.com/file/d/1jjzMocc0Rn9TqkK_51Oo93Fy78KYnm2i/view?usp=sharing).
This is a text file, each line of which has the following format:  
1. $remote_addr - - [$local_time] “$request” $status $bytes_send.
2. $remote_addr - request source.
3. $local_time - time of the source.
4. $request - the source.
5. $status - response status.
6. $bytes_send - the number of bytes transmitted in the response.
For example, 198.112.92.15 - - [03/Jul/1995:10:50:02 -0400] "GET /shuttle/countdown/
HTTP/1.0" 200 3985.
- Prepared a list of queries that ended in a 5xx error, with the
number of failed queries.
- Found the time window (duration is parameterized) when
the number of requests to the server was maximized.
