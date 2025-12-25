# Architecture Documentation

This folder contains C4 model architecture diagrams for the Contractors Platform website.

## C4 Model Overview

The C4 model provides a hierarchical set of software architecture diagrams:

1. **Context** - Shows the system in scope and its relationships with users and external systems
2. **Container** - Decomposes the system into interrelated containers (applications, data stores, etc.)
3. **Component** - Decomposes containers into interrelated components
4. **Deployment** - Shows how containers are deployed to infrastructure

## Diagrams

### 1. System Context Diagram
**File:** [c4-context.puml](./c4-context.puml)

Shows the Contractors Platform website and its relationships with:
- **Users:** Website visitors, Admin users
- **External Systems:** Email service, Google Maps, Analytics, reCAPTCHA, Cloud Storage, CRM

```
┌─────────────────────────────────────────────────────────────┐
│                         CONTEXT                              │
│                                                              │
│    [Visitor] ──────► [Contractors Platform] ◄────── [Admin] │
│                              │                               │
│                              ▼                               │
│         ┌────────────────────┴────────────────────┐         │
│         ▼           ▼           ▼           ▼      ▼        │
│     [Email]    [Maps]    [Analytics]  [reCAPTCHA] [CRM]    │
│                                                              │
└─────────────────────────────────────────────────────────────┘
```

### 2. Container Diagram
**File:** [c4-container.puml](./c4-container.puml)

Shows the major containers within the system:
- **Web Application** (Next.js) - Server-side rendered React application
- **API Server** (Node.js/Express) - Handles forms and backend logic
- **CMS** (Headless CMS) - Content management
- **Database** (PostgreSQL) - Data persistence
- **Cache** (Redis) - Performance optimization
- **CDN** - Static asset delivery

```
┌─────────────────────────────────────────────────────────────┐
│                       CONTAINERS                             │
│  ┌─────────────────────────────────────────────────────┐    │
│  │              Contractors Platform                    │    │
│  │  ┌───────┐  ┌───────┐  ┌─────┐  ┌────┐  ┌───────┐  │    │
│  │  │  CDN  │  │  SPA  │  │ API │  │ DB │  │ Cache │  │    │
│  │  └───────┘  └───────┘  └─────┘  └────┘  └───────┘  │    │
│  │                 │                                    │    │
│  │            ┌────┴────┐                              │    │
│  │            │   CMS   │                              │    │
│  │            └─────────┘                              │    │
│  └─────────────────────────────────────────────────────┘    │
└─────────────────────────────────────────────────────────────┘
```

### 3. Component Diagram
**File:** [c4-component.puml](./c4-component.puml)

Details the components within:

**Web Application Components:**
- Layout Components (Header, Footer, Navigation)
- Page Components (Home, Services, Projects, About, Contact)
- Reusable UI Components (Hero, Gallery, Carousel, Forms, Cards)
- Feature Components (Before/After Slider, Statistics Counter, Map)

**API Server Components:**
- Controllers (Lead, Upload, Content)
- Services (Lead, Email, Upload, Cache)
- Middleware (Validation, Rate Limiting, reCAPTCHA)

### 4. Deployment Diagram
**File:** [c4-deployment.puml](./c4-deployment.puml)

Shows infrastructure and deployment:
- **Client:** Web browsers
- **CDN:** Edge caching network
- **Cloud Platform:** Web tier, API tier, Data tier, Storage
- **CMS Platform:** Headless CMS service
- **External Services:** SendGrid, Google Maps, reCAPTCHA, Analytics

## Technology Stack

| Layer | Technology | Purpose |
|-------|------------|---------|
| Frontend | Next.js / React | Server-side rendering, routing |
| Styling | Tailwind CSS | Utility-first CSS |
| API | Node.js / Express | Backend services |
| Database | PostgreSQL | Data persistence |
| Cache | Redis | Performance caching |
| CMS | Contentful/Sanity | Content management |
| CDN | CloudFront/Vercel | Asset delivery |
| Storage | AWS S3 | File storage |
| Email | SendGrid | Transactional emails |
| Analytics | Google Analytics 4 | Traffic tracking |
| Maps | Google Maps API | Location display |
| Security | reCAPTCHA v3 | Spam protection |

## Rendering Diagram

To render these PlantUML diagrams:

### Option 1: PlantUML Online Server
Visit [http://www.plantuml.com/plantuml/uml/](http://www.plantuml.com/plantuml/uml/) and paste the diagram code.

### Option 2: VS Code Extension
Install the "PlantUML" extension and preview diagrams directly in VS Code.

### Option 3: Command Line
```bash
# Install PlantUML
brew install plantuml  # macOS
apt-get install plantuml  # Ubuntu

# Generate PNG
plantuml c4-context.puml

# Generate SVG
plantuml -tsvg c4-context.puml
```

### Option 4: Docker
```bash
docker run -v $(pwd):/data plantuml/plantuml c4-context.puml
```

## Architecture Decisions

### ADR-001: Next.js for Server-Side Rendering
- **Decision:** Use Next.js for the web application
- **Rationale:** SEO is critical for a marketing website; SSR improves crawlability and performance
- **Consequences:** Requires Node.js hosting, but provides excellent developer experience

### ADR-002: Headless CMS for Content
- **Decision:** Use a headless CMS for managing dynamic content
- **Rationale:** Allows non-technical staff to update projects, testimonials, and service info
- **Consequences:** Additional cost, but reduces developer dependency for content updates

### ADR-003: CDN for Static Assets
- **Decision:** Serve all static assets through a CDN
- **Rationale:** Improves performance and reduces origin server load
- **Consequences:** Slight complexity in deployment, but significant performance gains

### ADR-004: PostgreSQL for Data Storage
- **Decision:** Use PostgreSQL as the primary database
- **Rationale:** Reliable, well-supported, handles all data requirements
- **Consequences:** Requires managed database service or self-hosting

## Security Considerations

1. **HTTPS Everywhere** - All traffic encrypted
2. **Input Validation** - Server-side validation for all inputs
3. **Rate Limiting** - Prevents abuse of form submissions
4. **reCAPTCHA** - Protects forms from bots
5. **CSRF Protection** - Tokens for form submissions
6. **Content Security Policy** - Prevents XSS attacks
7. **Secure Headers** - HSTS, X-Frame-Options, etc.

## Performance Targets

| Metric | Target |
|--------|--------|
| First Contentful Paint | < 1.5s |
| Largest Contentful Paint | < 2.5s |
| Time to Interactive | < 3.5s |
| Cumulative Layout Shift | < 0.1 |
| Lighthouse Score | > 90 |

## Related Documents

- [Requirements](../requirements.md)
- [Features](../features/)
- [Wireframes](../wireframes/)
- [CSS Specifications](../css/)
