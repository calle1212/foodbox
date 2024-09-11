import { createLazyFileRoute } from '@tanstack/react-router'
import AdvertPage from '../components/AdvertPage'

export const Route = createLazyFileRoute('/deal')({
  component: AdvertPage
})