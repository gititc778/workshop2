#!/bin/bash

# Create project structure

mkdir -p demo-app/src/main/java/com/example/demo
cd demo-app

# ----------------------

# Create pom.xml

# ----------------------

cat <<EOF > pom.xml <project xmlns="http://maven.apache.org/POM/4.0.0" 
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

```
<modelVersion>4.0.0</modelVersion>

<groupId>com.example</groupId>
<artifactId>demo</artifactId>
<version>1.0.0</version>

<parent>
    <groupId>org.springframework.boot</groupId>
    <artifactId>spring-boot-starter-parent</artifactId>
    <version>3.2.0</version>
</parent>

<dependencies>
    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-web</artifactId>
    </dependency>

    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-actuator</artifactId>
    </dependency>
</dependencies>

<properties>
    <java.version>17</java.version>
</properties>
```

</project>
EOF

# ----------------------

# Create Main Class

# ----------------------

cat <<EOF > src/main/java/com/example/demo/DemoApplication.java
package com.example.demo;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class DemoApplication {
public static void main(String[] args) {
SpringApplication.run(DemoApplication.class, args);
}
}
EOF

# ----------------------

# Create Controller

# ----------------------

cat <<EOF > src/main/java/com/example/demo/HelloController.java
package com.example.demo;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelloController {

```
@GetMapping("/")
public String home() {
    return "Hello from Java Spring Boot App 🚀";
}

@GetMapping("/health")
public String health() {
    return "UP";
}
```

}
EOF

# ----------------------

# Create Dockerfile

# ----------------------

cat <<EOF > Dockerfile
FROM maven:3.9.6-eclipse-temurin-17 AS build

WORKDIR /app
COPY . .
RUN mvn clean package -DskipTests

FROM eclipse-temurin:17-jdk

WORKDIR /app
COPY --from=build /app/target/*.jar app.jar

EXPOSE 8080

CMD ["java", "-jar", "app.jar"]
EOF

echo "Project created successfully!"
echo "Next steps:"
echo "cd demo-app"
echo "docker build -t java-demo ."
echo "docker run -d -p 8080:8080 java-demo"
