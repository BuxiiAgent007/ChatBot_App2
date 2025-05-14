
CyberSecurity ChatBot
=====================

A console-based interactive chatbot built with C# that educates users on cybersecurity best practices in a friendly and engaging manner. Users can ask questions on topics such as passwords, scams, privacy, phishing, and safe browsing. The bot responds intelligently, detecting sentiment and personalizing its replies.

Features
--------

- Interactive chat with real-time input
- Responds based on keywords and cybersecurity topics
- Detects user sentiment (positive/negative)
- Offers personalized responses based on user preferences
- Typing effect for realistic interaction
- Console-based user interface


Follow the chatbot's prompts in the console.

How It Works
------------

- When the app starts, it prompts the user for their name and favorite cybersecurity topic.
- The chatbot listens to user input in a loop until the user types "exit".
- It matches input against predefined cybersecurity topics.
- Responses are chosen randomly from a pool under each topic.
- Detects sentiment (like "worried" or "excited") and tailors its tone accordingly.

Supported Topics
----------------

- password
- scam
- privacy
- phishing
- safe browsing
- Chatbot-related questions like:
  - "how are you"
  - "what's your purpose"
  - "what can I ask you about"

Project Structure
-----------------

- `chatbot_two`: Main chatbot class that handles interaction logic.
- `Topic` class: Holds keyword-specific responses and provides a random one per query.
- Sentiment Detection: Uses keyword matching to adjust the chatbot's tone.
- Typing Effect: Simulates a more human-like response by adding a delay between characters.

Customization
-------------

You can expand this chatbot by:
- Adding more topics and responses
- Improving sentiment detection with NLP libraries
- Creating a GUI interface for richer user interaction
- Persisting user preferences across sessions

Disclaimer
----------

This chatbot is for educational purposes only. It does not provide professional cybersecurity advice or services.


