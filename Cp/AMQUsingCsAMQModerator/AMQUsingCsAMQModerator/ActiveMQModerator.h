#pragma once

// Define the export macro for the class. This macro will be used to
// export the class when building the DLL, and import the class when
// using the DLL in another project.
#ifdef AMQMODERATOR_EXPORTS
#define AMQMODERATOR_API __declspec(dllexport)
#else
#define AMQMODERATOR_API __declspec(dllimport)
#endif

// AMQModerator class declaration
class AMQMODERATOR_API AMQModerator {
public:
    // Constructor with parameters
    AMQModerator(const char* brokerUri, const char* queueName, const char* topicName);

    // Destructor (if necessary)
    ~AMQModerator();

    // Other public methods for the class, e.g., Connect, SendMessage, etc.

private:
    // Private member variables for the class, e.g., brokerUri, queueName, topicName, etc.
    const char* brokerUri;
    const char* queueName;
    const char* topicName;

    // Private methods (if any) used only internally by the class
};