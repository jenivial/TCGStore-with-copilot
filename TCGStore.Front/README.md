# Next.js Vertical Slices

This project is structured using Vertical Slice Architecture, organizing features by slice. Each slice owns its API, domain, handlers, and persistence concerns, ensuring clear boundaries and separation of concerns.

## Project Structure

```
├── src
│   ├── app
│   │   ├── layout.tsx          # Layout component for consistent page structure
│   │   ├── page.tsx            # Main entry point for the application
│   │   └── api
│   │       └── health
│   │           └── route.ts    # API route for health checks
│   ├── slices
│   │   ├── catalog
│   │   │   ├── api
│   │   │   │   └── route.ts    # API route for catalog operations
│   │   │   ├── domain
│   │   │   │   └── types.ts     # Domain types for catalog
│   │   │   ├── handlers
│   │   │   │   └── index.ts     # Business logic for catalog
│   │   │   ├── persistence
│   │   │   │   └── repository.ts # Data access for catalog
│   │   │   └── ui
│   │   │       └── components.tsx # UI components for catalog
│   │   └── orders
│   │       ├── api
│   │       │   └── route.ts     # API route for order operations
│   │       ├── domain
│   │       │   └── types.ts      # Domain types for orders
│   │       ├── handlers
│   │       │   └── index.ts      # Business logic for orders
│   │       ├── persistence
│   │       │   └── repository.ts  # Data access for orders
│   │       └── ui
│   │           └── components.tsx # UI components for orders
│   ├── lib
│   │   └── db.ts                # Database connection logic
│   └── types
│       └── index.ts             # Shared types across the application
├── package.json                  # npm configuration
├── tsconfig.json                 # TypeScript configuration
├── next.config.js                # Next.js configuration
└── README.md                     # Project documentation
```

## Getting Started

1. **Clone the repository:**
   ```
   git clone <repository-url>
   cd nextjs-vertical-slices
   ```

2. **Install dependencies:**
   ```
   npm install
   ```

3. **Run the development server:**
   ```
   npm run dev
   ```

4. **Access the application:**
   Open your browser and navigate to `http://localhost:3000`.

## Features

- Health check API to verify application status.
- Catalog management with dedicated API, domain logic, and UI components.
- Order processing with its own API, domain logic, and UI components.
- Cards slice wired to the backend cards endpoints for list and detail views.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or features.

## License

This project is licensed under the MIT License. See the LICENSE file for details.